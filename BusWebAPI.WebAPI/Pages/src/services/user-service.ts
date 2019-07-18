import { json } from 'aurelia-fetch-client';
import { AuthHttpClient } from './../resources/auth-http-client';
import { autoinject } from "aurelia-framework";


@autoinject()
export class UserService {

  constructor(private authHttpClient: AuthHttpClient) {}

  async getAllUsers() {
    const res = await this.authHttpClient.fetch('/api/User/GetAllUsers');
    return await res.json();
  }

  verifyUserRequest(verifyUserDetails) {
    return this.authHttpClient.fetch('/api/User/VerifyUserRequest', {
      method: "put",
      body: json(verifyUserDetails)
    });
  }
  
  declineUseRequest(userID) {
    return this.authHttpClient.fetch('/api/User/DeclineUserRequest?userID=' + userID);
  }

  async changePerms(changePermsDetails) {
    return this.authHttpClient.fetch('/api/User/ChangePerms', {
      method: "put",
      body: json(changePermsDetails)
    });
  }

  changePassword(changePasswordDetails) {
    return this.authHttpClient.fetch('/api/User/ChangePassword', {
      method: "put",
      body: json(changePasswordDetails)
    });
  }

  resetPassword(userID) {
    return this.authHttpClient.fetch('/api/User/ResetPassword?userID=' + userID);
  }

  deleteUser(userID) {
    return this.authHttpClient.fetch('/api/User/DeleteUser?userID=' + userID);
  }

}
