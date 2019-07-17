import { json } from 'aurelia-fetch-client';
import { AuthHttpClient } from './../resources/auth-http-client';
import { autoinject } from "aurelia-framework";
import * as toastr from 'toastr';

@autoinject()
export class AuthService {

  constructor(private authHttpClient: AuthHttpClient) {
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

  register(registerDetails) {
    return this.authHttpClient.fetch('/api/Auth/Register', {
      method: "POST",
      body: json(registerDetails)
    }).then(res => res.json());
  }

  login(loginDetails) {
    return this.authHttpClient.fetch('/api/Auth/Login', {
      method: "POST",
      body: json(loginDetails)
    }).then(res => res.json());
  }

  logout() {
    localStorage.clear();
  }

  checkIfLogged() {
    return this.authHttpClient.fetch("/api/Auth/CheckIfLogged")
    .then(res => res.json())
  }

  checkIfAdmin() {
    return this.authHttpClient.fetch("/api/Auth/CheckIfAdmin")
    .then(res => res.json());
  }
}
