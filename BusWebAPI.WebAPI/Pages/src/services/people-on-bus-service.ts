import { AuthHttpClient } from './../resources/auth-http-client';
import { autoinject } from "aurelia-framework";
import { json } from 'aurelia-fetch-client';
@autoinject()
export class PeopleOnBusService {

  constructor(private authHttpClient: AuthHttpClient, private router: Router){}

  registerToBus() {
    return this.authHttpClient.fetch("/api/PEopleOnbus/RegisterToBus")
    .then(res => res.json())
  }
}