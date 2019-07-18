import { UserService } from './../services/user-service';
import { autoinject } from "aurelia-framework";
import * as toastr from 'toastr';

@autoinject()
export class AdminChangePassword {    
  
  constructor(private userService: UserService) {}

  oldPassword;
  newPassword;
  newPasswordConfirm;

  changePassword() {

    if(this.newPassword === this.newPasswordConfirm) 
    {
      const changePasswordDetails = {
        OldPassword: this.oldPassword,
        NewPassword: this.newPassword
      };
      
      this.userService.changePassword(changePasswordDetails)
      .then(_ => toastr.success("הססמא שונתה בהצלחה"))
      .catch(_ => toastr.error("בעיה בשינוי הססמא. וודא שהססמא הישנה שהקשת נכונה. שים לב לאותיות גדולות"));

    } else {
      toastr.error("הססמאות שהקשת אינן זהות");
    }

  }
}
