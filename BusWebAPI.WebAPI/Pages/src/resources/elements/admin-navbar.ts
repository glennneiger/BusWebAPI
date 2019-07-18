import { AuthService } from './../../services/auth-service';
import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";
import * as toastr from 'toastr';

@autoinject()
export class AdminNavbar {

  constructor(private router: Router, private authService: AuthService){
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

  isLogged: boolean;
  isAdmin: boolean;

  attached() { 
    this.checkIfLogged();
  }

  checkIfLogged() {
    this.authService.checkIfLogged()
    .then(_ => this.isLogged = true)
    .catch(_ => {
      this.router.navigateToRoute('home');
      toastr.error("עליך להתחבר בכדי לצפות בעמוד זה");
    });
    this.authService.checkIfAdmin()
    .then(_ => this.isAdmin = true)
    .catch(_ => {
      this.isAdmin = false;
      if(this.isLogged && !this.isAdmin) {
        toastr.error("אין לך הרשאות לצפות בעמוד זה");
      }
    });  
  }
}

