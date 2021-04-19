import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressBarService } from 'src/app/shared/services/progress-bar.service';
import { AlertService } from 'ngx-alerts';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  constructor(private authService: AuthService, public progressBar: ProgressBarService,
    private alertService: AlertService) { }

  ngOnInit() {
  }

  onSubmit(f: NgForm) {
    this.alertService.info('Working on sending email');
    this.progressBar.startLoading();
  }
}
