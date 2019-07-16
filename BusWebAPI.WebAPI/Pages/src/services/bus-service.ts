import { autoinject } from "aurelia-framework";
import { AuthHttpClient } from './../resources/auth-http-client';

@autoinject()
export class BusService {

  constructor(private authHttpClient: AuthHttpClient){}

  GetBusList() {
    return this.authHttpClient.fetch("/api/Bus/GetBusList")
    .then(res => res.json());
  }

  GetBusByID(busID) {
    return this.authHttpClient.fetch("/api/Bus/GetBusByID?busID=" + busID)
    .then(res => res.json());
  } 

}
