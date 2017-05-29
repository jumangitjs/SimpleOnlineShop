import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';

// import * as fromRoot from '../store/reducers/index'; add this shit later on

@Injectable()
export class AuthGuard implements CanActivate {

  // constructor(private store: Store<fromRoot.AppState>,
  //             private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }
}
