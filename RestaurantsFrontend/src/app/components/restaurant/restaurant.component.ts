import { Component, OnInit } from '@angular/core';
import { Dish } from 'src/app/models/dish';
import { Restaurant } from 'src/app/models/restaurant';
import { DishService } from 'src/app/services/dish.service';
import { RestaurantServiceService } from 'src/app/services/restaurant-service.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {

  public restaurants: Restaurant[] = [];
  public menu: Dish[] = [];

  public id: number;
  public title: string;
  public customers: number;
  public employees: number;
  public dishId: number;

  public filterDishId: number;

  public displaySaveButton = true;
  public displayUpdateButton = false;

  constructor(
    private restaurantService: RestaurantServiceService,
    private dishService: DishService,
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.restaurantService.getAll().subscribe((data) => {
      this.restaurants = data;
    });
    // this.dishService.getAll().subscribe((data) => {
    //   this.menu = data;
    // });
    this.sharedService.getMenu().subscribe(dishes => {
      console.log('from shared service', dishes);
      this.menu = dishes;
    });
  }

  public createRestaurant() : void {
    let newRestaurant: Restaurant = {
      title: this.title,
      customers: this.customers,
      employees: this.employees,
      dishId: this.dishId
    }
    this.restaurantService.create(newRestaurant).subscribe((restaurantWithId) => {this.restaurants.push(restaurantWithId)});
    this.title = "";
    this.customers = null;
    this.employees = null;
    this.dishId = null;
  }

  public deleteRestaurant(id: number) : void {
    this.restaurantService.delete(id).subscribe(() => {
      this.restaurants = this.restaurants.filter((restaurant) => {
        return restaurant.id != id
      })
    });
  }

  public updateRestaurant(restaurant: Restaurant) : void {
    this.displayUpdateButton = true;
    this.displaySaveButton = false;
    this.id = restaurant.id;
    this.title = restaurant.title;
    this.employees = restaurant.employees;
    this.customers = restaurant.customers;
    this.dishId = restaurant.dishId;
  }

  public saveUpdatedRestaurant() : void {
    let updatedRestaurant: Restaurant = {
      id: this.id,
      title: this.title,
      customers: this.customers,
      employees: this.employees,
      dishId: this.dishId
    }
    console.log(updatedRestaurant);
    
    this.restaurantService.update(updatedRestaurant).subscribe((updatedRestaurant) => {
      this.restaurants = this.restaurants.map(restaurant => restaurant.id !== updatedRestaurant.id ? restaurant : updatedRestaurant)
    });
    this.displayUpdateButton = false;
    this.displaySaveButton = true;
    this.title = "";
    this.customers = null;
    this.employees = null;
    this.dishId = null;
  }

  public filterByDish(filterDishId: number) : void {
    this.restaurantService.getByDishId(filterDishId).subscribe((data) => {
      this.restaurants = data;
    });
  }

}
