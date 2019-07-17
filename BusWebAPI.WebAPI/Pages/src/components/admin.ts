import { BusService } from './../services/bus-service';
import { AuthService } from './../services/auth-service';
import { autoinject } from 'aurelia-framework';
import * as moment from 'moment';
import { Router } from "aurelia-router";

@autoinject()
export class Admin {    
  
  constructor(private authService: AuthService, private busService: BusService, private router: Router) {}
  busList: any;
  seats: string;

  attached() {
    this.busService.getBusList()
    .then(data => {
      this.busList = data;
      this.busList.map(bus => {
        bus.DateTime = moment(bus.DateTime).format('hh:mm, DD/MM/YYYY');
        bus.SeatsTaken = 0;
        bus.PeopleOnBus.forEach(p => {
          if(p.IsVerified) {
            bus.SeatsTaken++;
          }
        });
      });
    });
  }

  viewBusAsAdmin(busID) {
    this.router.navigateToRoute('view-bus-admin', {busID});
  }

}
