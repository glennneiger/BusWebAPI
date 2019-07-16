import { BusService } from './../services/bus-service';
import { autoinject } from "aurelia-framework";
import * as moment from 'moment';
@autoinject()
export class ViewBus {    
  
  constructor(private busService: BusService) {}

  bus: any;
  activate(params) {
    this.busService.GetBusByID(params.busID)
    .then(data => {
      this.bus = data;
      this.bus.SeatsTaken = 0;
      this.bus.DateTime = moment(this.bus.DateTime).format('hh:mm, DD/MM/YYYY');
      this.bus.PeopleOnBus.map(p => {
        if(p.IsVerified) {
          this.bus.SeatsTaken++;
        }
      });
    });

  }
}
