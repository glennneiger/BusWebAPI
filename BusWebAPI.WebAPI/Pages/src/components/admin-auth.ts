import { UserService } from './../services/user-service';
import { autoinject } from 'aurelia-framework';
import * as toastr from 'toastr';


@autoinject()
export class AdminAuth {    
  constructor(private userService: UserService) {}

  userList: any;

  showResetConfirmBox;
  showDeclineUserRequestBox;
  showDeleteUserConfirmBox

  attached() {
    this.getAllUsers();
  }

  getAllUsers() {
    this.userService.getAllUsers()
    .then(data => {
      this.userList = data;
      console.log(this.userList);
    })
    .catch(_ => toastr.error("לא ניתן לקבל רשימת משתמשים כרגע"));
  }
 
  resetPassword(userID) {
    this.userService.resetPassword(userID)
    .then(_ => {
      toastr.success("איפוס הססמא הצליח. הססמא החדשה היא: Aa123456. נא לשים לב לאותיות גדולות וקטנות");
      this.showResetConfirmBox = false;
    })
    .catch(_ => toastr.error("שינוי הססמא לא הצליח. אם הבעיה ממשיכה פנה למנהל המערכת"));
  }
  
  verifyUserRequest(userID) {
    const verifyUserDetails = {
      UserID: userID,
      IsAdmin: false
    };
    this.userService.verifyUserRequest(verifyUserDetails)
    .then(_ => toastr.success("אישור המשתמש הצליח. המשתמש קיבל הרשאות רגילות. ניתן לשנות להרשאות מנהל במידת הצורך"))
    .catch(_ => toastr.error("אישור המשתמש לא הצליח. אם הבעיה ממשיכה פנה למנהל המערכת"));
  }

  declineUserRequest(userID) {
    this.userService.declineUseRequest(userID)
    .then(_ => {
      toastr.success("דחיית בקשת המשתמש הצלחה");
      this.showDeclineUserRequestBox = false;
      this.getAllUsers();
    })
    .catch(_ => toastr.error("דחיית בקשה לא הצליחה. אם הבעיה ממשיכה פנה למנהל המערכת"));
  }

  changePerms(userID) {
    const getUserDetails = this.userList.find(u => u.ID === userID);
    const changePermsDetails = {
      UserID: userID,
      IsAdmin: !getUserDetails.IsAdmin
    };
    
    this.userService.changePerms(changePermsDetails)
    .then(_ => {
      toastr.success("הרשאות הוחלפו בהצלחה, השינויים ייכנסו לתוקף החל מההתחברות הבאה למערכת.");
      this.getAllUsers();
    })
    .catch(_ => toastr.error("החלפת הרשאות לא הצליחה. אם הבעיה ממשיכה פנה למנהל המערכת"));
  }

  deleteUser(userID) {
    this.userService.deleteUser(userID)
    .then(_ => {
      toastr.success("המשתמש נמחק בהצלחה");
      this.getAllUsers();
    })
    .catch(_ => {
        toastr.error("לא ניתן למחוק את המשתמש");
        this.showDeleteUserConfirmBox = false;
    });
  }
}
