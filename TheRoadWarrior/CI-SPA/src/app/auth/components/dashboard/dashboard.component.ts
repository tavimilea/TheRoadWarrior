import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressBarService } from 'src/app/shared/services/progress-bar.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private authService: AuthService, public progressBar: ProgressBarService,
    private alertService: AlertService) { }

  ngOnInit() {
  }

  clicked = 0;

  f : NgForm;
  g : NgForm;
  h : NgForm;
  
  TRIPS = [];
  onSubmit(f : NgForm) {


    const tripObserver = {
      next: x => console.log('trip added'),
      error: err => console.error(err)
    };

    const HotelObserver = {
      next: x => console.log('hotel added'),
      error: err => console.error(err)
    };

    const carObserver = {
      next: x => console.log('car added'),
      error: err => console.error(err)
    };

    

    if (this.clicked == 0) {
      this.f = f;
      console.log(this.f.value.tripName);
      this.AddObject(this.f.value.tripName);
      console.log(this.GetTrips());
  
      this.authService.dashboard(this.f.value).subscribe(tripObserver);
    }
    else if (this.clicked == 1) {
      this.g = f;
      console.log(this.g.value)
      this.authService.dashboardHotel(this.g.value).subscribe(HotelObserver);
    }
    else {
      console.log(this.h.value)
      this.authService.dashboardCar(this.h.value).subscribe(carObserver);

    }



  }

  public AddObject( name :any ):  void {
    this.TRIPS.push(name)

  }

  public GetTrips () : any {
    return this.TRIPS;
  }

  public FirstClick(): void {
    this.clicked = 0;
    console.log(this.clicked);
  }

  public SecondClick(): void {
    this.clicked = 1;
    console.log(this.clicked);
  }

  public ThirdClick(): void {
    this.clicked = 2;
    console.log(this.clicked);
  }


}
