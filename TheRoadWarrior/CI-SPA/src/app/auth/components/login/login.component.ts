import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressBarService } from 'src/app/shared/services/progress-bar.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, public progressBar: ProgressBarService,
    private alertService: AlertService) { }

  ngOnInit() {
  }

  onSubmit(f: NgForm) {

    const loginObserver = {
      next: x => console.log('user logged'),
      error: err => console.error(err)
    };

    this.authService.login(f.value).subscribe(loginObserver);
    this.alertService.info('Checking User Info');
    this.progressBar.startLoading();
    }

}

