import { PeopleOnBusService } from './../services/people-on-bus-service';
import { Router } from 'aurelia-router';
import { BusService } from './../services/bus-service';
import { autoinject } from "aurelia-framework";
import * as moment from 'moment';
import * as toastr from 'toastr';

@autoinject()
export class ViewBusAdmin {    

  constructor(private busService: BusService, private router: Router, private pobService: PeopleOnBusService) {}

  bus: any;
  busID: number;

  verifiedPeople = [];
  declinedPeople = [];
  waitingPeople = [];

  activate(params) {
    this.busID = params.busID;


    this.busService.getBusByID(params.busID)
    .then(data => {
      this.bus = data;
      this.bus.SeatsTaken = 0;
      this.bus.DateTime = moment(this.bus.DateTime).format('hh:mm, DD/MM/YYYY');
      this.bus.PeopleOnBus.map(p => {
        if(p.IsVerified) {
          this.bus.SeatsTaken++;
          this.verifiedPeople.push(p);
        } else if(!p.IsVerified && p.IsHidden) {
          this.declinedPeople.push(p);
        }
      });
      this.pobService.getRideRequests(this.busID)
      .then(data => this.waitingPeople = data);
      
    })
    .catch(e => {
      toastr.error("חסר לך הרשאות. נסה להתחבר מחדש או לבקש הרשאות ממנהל מערכת");
      this.router.navigateToRoute("home");
    });


  }

  registerToBus() {
    this.router.navigateToRoute("register-bus", {busID: this.busID})
  }
}
