import { BusService } from './../services/bus-service';
import { AuthService } from './../services/auth-service';
import { autoinject } from 'aurelia-framework';
import * as moment from 'moment';
import { Router } from "aurelia-router";
import * as toastr from 'toastr';


@autoinject()
export class AdminHistory {    
  constructor(private authService: AuthService, private busService: BusService, private router: Router) {
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
  busList: any;
  seats: string;

  attached() {
    this.busService.getBusHistory()
    .then(data => {
      this.busList = data;
      console.log(this.busList);
      this.busList.map(bus => {
        bus.DateTime = moment(bus.DateTime).format('hh:mm, DD/MM/YYYY');
        bus.SeatsTaken = 0;
        bus.PeopleOnBus.forEach(p => {
          if(p.IsVerified) {
            bus.SeatsTaken++;
          }
        });
      })
    })
    .catch(_ => {
      this.router.navigateToRoute('home');
      toastr.error("אינך רשאי לצפות בעמוד זה");
    });
  }

  viewBusAdmin(busID) {
    this.router.navigateToRoute('view-bus-history-admin', { busID });
  }


}
