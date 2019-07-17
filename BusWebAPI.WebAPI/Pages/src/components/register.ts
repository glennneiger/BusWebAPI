import { AuthService } from './../services/auth-service';
import { autoinject } from "aurelia-framework";
import * as toastr from 'toastr';
import { Router } from 'aurelia-router';

@autoinject()
export class Register {    
  
  constructor(private authService: AuthService, private router: Router) {
    toastr.options = {
      "closeButton": false,
      "debug": false,
      "newestOnTop": false,
      "progressBar": false,
      "positionClass": "toast-bottom-right",
      "preventDuplicates": true,
      "onclick": null,
      "showDuration": "300",
      "hideDuration": "1000",
      "timeOut": "5000",
      "extendedTimeOut": "1000",
      "showEasing": "swing",
      "hideEasing": "linear",
      "showMethod": "fadeIn",
      "hideMethod": "fadeOut"
    }
  }

  personalID;
  password;
  confirmPassword;

  register() {
    if(this.password === this.confirmPassword) {
      const registerDetails = 
      {
        PersonalID: this.personalID,
        Password: this.password
      };
      this.authService.register(registerDetails)
      .then(data => {
        this.router.navigateToRoute("home");
        toastr.success("נרשמת בהצלחה. בכדי להתחבר בקש מהאחראי עליך לאשר את בקשתך.");
      })
      .catch(_ => toastr.error("תקלה בהרשמה, וודא שמילאת את כל הפרטים ושהמשתמש לא נרשם בעבר למערכת. אם התקלה נמשכת פנה למנהל מערכת."));
    } else {
      toastr.warning("הססמאות שהקשת לא זהות");
    }

  }

}
