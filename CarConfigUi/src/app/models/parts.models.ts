import {User} from "./user.model";
import {Comment} from "./comment.model";

export class Mechanical{
    gearbox: Part[]
    suspension: Part[]
}
export enum primaryType{
  MECHANICAL = "MECHANICAL",
  EXTERIOR = "EXTERIOR",
  INTERIOR = "INTERIOR",
  OPTIONAL = "OPTIONAL",
}
export enum secondaryType{
  GEARBOX = "GEARBOX",
  SUSPENSION = "SUSPENSION",
  ENGINE = "ENGINE",
  COLOR = "COLOR",
  RIM = "RIM",
  BRAKE = "BRAKE",
  CAR_SEAT = "CAR_SEAT",
  INTERIOR_MATERIAL = "INTERIOR_MATERIAL",
  ASSISTING_SYSTEM = "ASSISTING_SYSTEM",
  INTERIOR_EQUIPMENT = "INTERIOR_EQUIPMENT",
  AUDIO = "AUDIO",
}

export interface Exterior{
  color: Part[];
  rims: Part[];
  brakes: Part[];
}

export interface Interior {
  material: Part[];
  seats: Part[];
}

export interface Options {
  assisting_systems: Part[];
  interior_equipment: Part[];
  audio_equipment: Part[];
}

export interface Part {
    id: number,
    name: string,
    price: number,
    primaryType: primaryType,
    secondaryType: secondaryType
}

export interface Car {
  id: number;
  brand: string;
  model: string;
  price: number;
  imageFolder: string;
}

export interface Configuration{
  createdByNavigation: User;
  id: number;
  createdOn: any;
  description: string;
  user: User;
  car: Car;
  totalPrice: number;
  comments: Comment[];
}
