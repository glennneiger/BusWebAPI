import { autoinject } from "aurelia-framework";
import { BusService } from "../services/bus-service";
import * as moment from 'moment';
import { Router } from "aurelia-router";

@autoinject()
export class Home {    
  message: string;
  
  constructor(private busService: BusService, private router: Router) { }

  busList: any;
  seats: string;

  attached() {
    this.busService.GetBusList()
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

  viewBus(busID) {
    this.router.navigateToRoute("view-bus", { busID })
  }

  registerBus(busID) {
    this.router.navigateToRoute("register-bus", { busID })
  }
}
