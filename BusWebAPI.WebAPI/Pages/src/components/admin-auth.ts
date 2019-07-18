import { UserService } from './../services/user-service';
import { autoinject } from 'aurelia-framework';
import * as toastr from 'toastr';


@autoinject()
export class AdminAuth {    
  constructor(private userService: UserService) {}

  userList: any;


  attached() {
    this.userService.getAllUsers()
    .then(data => this.userList = data)
    .catch(_ => toastr.error("לא ניתן לקבל רשימת משתמשים כרגע"));
  }

 
  resetPassword() {
    
  }
}
