import { PeopleOnBusService } from './../services/people-on-bus-service';
import { autoinject } from "aurelia-framework";
import * as toastr from 'toastr';
import { Router } from 'aurelia-router';

@autoinject()
export class RegisterBus {    
  
  constructor(private pobService: PeopleOnBusService, private router: Router) {
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
  
  busID: number;

  fullName: string;
  personalID: number;
  team: string;
  reason: string;
  commanderName: string;
  notes: string;


  activate(params) {
    this.busID = params.busID;
  }

  submit() {
    const registerToBus = 
    {
      FullName: this.fullName,
      PersonalID: this.personalID,
      Team: this.team,
      Reason: this.reason,
      CommanderName: this.commanderName,
      Notes: this.notes,
      BusID: this.busID
    }
    // TODO: prevent double registration to same bus. also on accepting (manager) send busID client + server!!!
    this.pobService.registerToBus(registerToBus)
    .then(data => {
      this.router.navigateToRoute('view-bus', {busID: this.busID});
      toastr.success("נרשמת בהצלחה. תצטרך להמתין לאישור. בעמוד זה תוכל לבדוק את סטטוס הבקשה שלך");
    })
    .catch(_ => toastr.error("לא ניתן להרשם יותר מפעם אחת לכל הסעה"));
  }
}
