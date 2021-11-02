import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from '../models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantServiceService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getAll(): Observable<Restaurant[]>{
    let url: string = 'https://localhost:44342/Restaurant';
    return this.http.get<Restaurant[]>(url);
  }

  public create(restaurant: Restaurant) : Observable<Restaurant> {
    return this.http.post<Restaurant>('https://localhost:44342/Restaurant', restaurant);
  }

  public delete(id: number) : Observable<Restaurant> {
    return this.http.delete<Restaurant>(`https://localhost:44342/Restaurant?id=${id}`);
  }

  public update(restaurant: Restaurant) : Observable<Restaurant> {
    return this.http.put<Restaurant>(`https://localhost:44342/Restaurant/${restaurant.id}`, restaurant);
  }

  public getByDishId(dishId: number): Observable<Restaurant[]>{
    return this.http.get<Restaurant[]>(`https://localhost:44342/dishId=${dishId}`);
  }
}
