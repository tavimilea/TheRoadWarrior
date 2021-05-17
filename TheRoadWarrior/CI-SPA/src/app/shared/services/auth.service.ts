import { Injectable } from "@angular/core";
import { HttpClient} from "@angular/common/http";
import { map } from "rxjs/operators";



@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = "https://localhost:44354/";

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'Login',model).pipe(
      map((response: any) => {
        const user = response;
        console.log(user);
        if(user.responseCode == 200){
          console.log(user.responseCode);
          localStorage.setItem('token',user.apiKey)
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'Register',model);
  }


  dashboard(model: any){
    return this.http.post(this.baseUrl + 'Trips', model)
  }

  dashboardHotel(model: any){
    return this.http.post(this.baseUrl + 'Trips/HotelReservations', model)
  }

  dashboardCar(model: any){
    return this.http.post(this.baseUrl + 'Trips/CarReservations', model)
  }

  getToken(){
  }

  loggedIn(){}

}
