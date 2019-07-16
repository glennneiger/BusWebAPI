import { PeopleOnBusService } from './../services/people-on-bus-service';
import { autoinject } from "aurelia-framework";

@autoinject()
export class RegisterBus {    
  
  constructor(private pobService: PeopleOnBusService) {}
  busID: number;

  activate(params) {
    this.busID = params.busID;
  }

  submit() {
    // TODO: !
    this.pobService.registerToBus();
  }
}