import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Dish } from '../models/dish';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private availableMenu = new BehaviorSubject<Dish[]>(null);

  constructor() { }

  loadMenu(dishes: Dish[]){
    this.availableMenu.next(dishes);
  }

  getMenu(): Observable<Dish[]> {
    return this.availableMenu.asObservable();
  }
}
