import { Injectable } from "@angular/core";
import { HttpClient} from "@angular/common/http";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  authUrl = "http://localhost:5000/api/auth/";
  employersUrl = "http://localhost:5000/api/employers/";
  confirmEmailUrl = "http://localhost:4200/confirm-email/";
  changePasswordUrl = "http://localhost:4200/change-password/";
  helper = new JwtHelperService();
  decodedToken: any;


  constructor(private http: HttpClient) {}

  login() {
  }

  register(model: any) {
  }

  resetPassword(model: any) {
  }

  confirmEmail(model: any) {
  }

  changePassword(model: any) {
  }

  loggedIn() {
  }
}
