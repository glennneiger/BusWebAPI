import { AuthService } from './../services/auth-service';
import { autoinject } from "aurelia-framework";
import * as toastr from 'toastr';
import { Router } from 'aurelia-router';

@autoinject()
export class Login {    
  
  constructor(private authService: AuthService, private router: Router) {  }

  personalID;
  password: string;

  login() {
    const loginDetails =
    {
      PersonalID: parseInt(this.personalID),
      Password: this.password
    }
    this.authService.login(loginDetails)
    .then(data => {
      this.router.navigateToRoute("admin");
      toastr.success("התחברת בהצלחה");
    })
    .catch(_ => toastr.error("שם משתמש או ססמא לא קיימים או לא נכונים"));
  }


}
