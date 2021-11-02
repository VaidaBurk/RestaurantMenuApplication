import { Restaurant } from "./restaurant";

export interface Dish {
    id?: number;
    title: string;
    price: number;
    weight: number;
    meatWeight: number;
    description: string;
}