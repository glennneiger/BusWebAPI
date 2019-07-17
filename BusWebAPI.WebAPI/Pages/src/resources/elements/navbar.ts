import { AuthService } from './../../services/auth-service';
import { Router } from 'aurelia-router';
import { autoinject } from 'aurelia-framework';

@autoinject()
export class Navbar {
  

  constructor(private router: Router, private authService: AuthService) {
    
  }

  isLogged: boolean;
  isAdmin: boolean;

  attached() {
    this.checkIfLogged();
  }

  checkIfLogged() {
    this.authService.checkIfLogged()
    .then(_ => this.isLogged = true)
    .catch(_ => this.isLogged = false);
    this.authService.checkIfAdmin()
    .then(_ => this.isAdmin = true)
    .catch(_ => this.isAdmin = false);  
  }

  logout() {
    this.authService.logout();
    this.checkIfLogged();
  }

}

