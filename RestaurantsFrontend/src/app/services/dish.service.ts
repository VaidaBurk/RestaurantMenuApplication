import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dish } from '../models/dish';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DishService {

  private http: HttpClient;

  private menuSource = new BehaviorSubject<Dish[]>([]);

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getAll(): Observable<Dish[]>{
    return this.http.get<Dish[]>('https://localhost:44342/Menu');
  }

  public delete(id: number) : Observable<Dish> {
    return this.http.delete<Dish>(`https://localhost:44342/Menu?id=${id}`);
  }

  public create(dish: Dish) : Observable<Dish> {
    return this.http.post<Dish>('https://localhost:44342/Menu', dish);
  }

  public update(dish: Dish) : Observable<Dish> {
    return this.http.put<Dish>(`https://localhost:44342/Menu/${dish.id}`, dish);
  }
}
