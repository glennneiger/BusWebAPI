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

  async registerToBus(registerToBus) {
    try {
      const res = await this.authHttpClient.fetch("/api/PeopleOnbus/RegisterToBus", {
        method: "POST",
        body: json(registerToBus)
      });
      return await res.json();
    }
    catch (_) {
      return toastr.danger("לא ניתן להרשם.");
    }
  }

  async getRideRequests(busID) {
    const res = await this.authHttpClient.fetch('/api/PeopleOnBus/GetRideRequests?busID=' + busID);
    return await res.json();
  }

  approveRideRequest(requestorID) {
    return this.authHttpClient.fetch('/api/PeopleOnBus/ApproveRideRequest?requestorID=' + requestorID);
  }

  declineRideRequest(requestorID) {
    return this.authHttpClient.fetch('/api/PeopleOnBus/DeclineRideRequest?requestorID=' + requestorID);
  }
}
