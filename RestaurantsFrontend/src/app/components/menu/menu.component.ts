import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Dish } from 'src/app/models/dish';
import { DishService } from 'src/app/services/dish.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit {

  public id: number;
  public title: string;
  public price: number;
  public weight: number;
  public meatWeight: number;
  public description: string;

  public displaySaveButton = true;
  public displayUpdateButton = false;
  
  public menu: Dish[] = [];


  constructor(
    private dishService: DishService,
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.dishService.getAll().subscribe((data) => {
      this.menu = data;
      this.sharedService.loadMenu(this.menu);
    });
  }

  public deleteDish(id: number) : void {
    this.dishService.delete(id).subscribe(() => {
      this.menu = this.menu.filter((dish) => {
        return dish.id != id
      })
    });
  }

  public createDish() : void {
    let newDish: Dish = {
      title: this.title,
      price: this.price,
      weight: this.weight,
      meatWeight: this.meatWeight,
      description: this.description
    }
    this.dishService.create(newDish).subscribe((dishWithId) => {this.menu.push(dishWithId)});
    this.sharedService.loadMenu(this.menu);
    
    this.title = "";
    this.price = null;
    this.weight = null;
    this.meatWeight = null;
    this.description = "";
    
    this.sharedService.loadMenu(this.menu);
  }

  public updateDish(dish: Dish) : void {
    this.displayUpdateButton = true;
    this.displaySaveButton = false;
    this.id = dish.id;
    this.title = dish.title;
    this.price = dish.price;
    this.weight = dish.weight;
    this.meatWeight = dish.meatWeight;
    this.description = dish.description;
  }

  public saveUpdatedDish() : void {
    let updatedDish: Dish = {
      id: this.id,
      title: this.title,
      price: this.price,
      weight: this.weight,
      meatWeight: this.meatWeight,
      description: this.description
    }
    
    this.dishService.update(updatedDish).subscribe(() => {
      this.menu = this.menu.map(dish => dish.id !== updatedDish.id ? dish : updatedDish)
      this.sharedService.loadMenu(this.menu);
    });

    this.displayUpdateButton = false;
    this.displaySaveButton = true;

    this.title = "";
    this.price = null;
    this.weight = null;
    this.meatWeight = null;
    this.description = "";
  }
}
