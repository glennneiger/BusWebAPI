import { AuthHttpClient } from './../resources/auth-http-client';
import { autoinject } from "aurelia-framework";
import { json } from 'aurelia-fetch-client';
import * as toastr from 'toastr';
import { Router } from 'aurelia-router';

@autoinject()
export class PeopleOnBusService {

  constructor(private authHttpClient: AuthHttpClient, private router: Router){
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

  registerToBus(registerToBus) {
    return this.authHttpClient.fetch("/api/PEopleOnbus/RegisterToBus", {
      method: "POST",
      body: json(registerToBus)
    })
    .then(res => res.json())
    .catch(_ => toastr.danger("לא ניתן להרשם."));
  }
}