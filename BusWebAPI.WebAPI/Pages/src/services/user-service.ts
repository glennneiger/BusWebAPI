import { AuthHttpClient } from './../resources/auth-http-client';
import { autoinject } from "aurelia-framework";


@autoinject()
export class UserService {

  constructor(private authHttpClient: AuthHttpClient) {}

  getAllUsers() {
    return this.authHttpClient.fetch('/api/User/GetAllUsers')
    .then(res => res.json());
  }

}
