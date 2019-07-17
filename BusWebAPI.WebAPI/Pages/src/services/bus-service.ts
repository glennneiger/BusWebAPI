import { autoinject } from "aurelia-framework";
import { AuthHttpClient } from './../resources/auth-http-client';
import * as toastr from 'toastr';

@autoinject()
export class BusService {

  constructor(private authHttpClient: AuthHttpClient){
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

  getBusList() {
    return this.authHttpClient.fetch("/api/Bus/GetBusList")
    .then(res => res.json());
  }

  getBusByID(busID) {
    return this.authHttpClient.fetch("/api/Bus/GetBusByID?busID=" + busID)
    .then(res => res.json());
  } 

}
