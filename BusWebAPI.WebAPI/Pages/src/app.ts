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
        { route: 'admin', name: 'admin', moduleId: PLATFORM.moduleName("components/admin"), title:'פאנל ניהול - ראשי' },
        { route: 'admin-history', name: 'admin-history', moduleId: PLATFORM.moduleName("components/admin-history"), title:'פאנל ניהול - היסטוריית הסעות' },
        { route: 'view-bus-admin/:busID', name: 'view-bus-admin', moduleId: PLATFORM.moduleName("components/view-bus-admin"), title:'פאנל ניהול - צפייה בהסעה' },
        { route: 'view-bus-history-admin/:busID', name: 'view-bus-history-admin', moduleId: PLATFORM.moduleName("components/view-bus-history-admin"), title:'פאנל ניהול - צפייה בהסעה - היסטוריה' },
        { route: 'admin-auth', name: 'admin-auth', moduleId: PLATFORM.moduleName("components/admin-auth"), title:'פאנל ניהול - הרשאות' },
        { route: 'admin-change-password', name: 'admin-change-password', moduleId: PLATFORM.moduleName("components/admin-change-password"), title:'פאנל ניהול - שינוי ססמא' },
      ]);
    }
  }
