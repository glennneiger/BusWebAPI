import { PLATFORM } from 'aurelia-pal';
import {RouterConfiguration, Router} from 'aurelia-router';
import 'aleph1-layout/dist/main.min.css';

  export class App {

    router: Router;


    configureRouter(config: RouterConfiguration, router: Router): void {
      this.router = router;
      config.title = 'ניהול הסעות - מעוף רחב';
      config.map([
        { route: '', name: 'home', moduleId: PLATFORM.moduleName("components/home"), title:'דף הבית' },
        { route: 'view-bus/:busID', name: 'view-bus', moduleId: PLATFORM.moduleName("components/view-bus"), title:'צפייה בהסעה' },
        { route: 'register-bus/:busID', name: 'register-bus', moduleId: PLATFORM.moduleName("components/register-bus"), title:'הרשמה להסעה' },
        { route: 'login', name: 'login', moduleId: PLATFORM.moduleName("components/login"), title:'התחברות' },
        { route: 'register', name: 'register', moduleId: PLATFORM.moduleName("components/register"), title:'הרשמה' },
        { route: 'admin', name: 'admin', moduleId: PLATFORM.moduleName("components/admin"), title:'פאנל ניהול - ראשי' }
      ]);
    }
  }
