import {User} from "./user.model";

export interface Comment {
  id?: number;
  text: string;
  createdOn?: number;
  createdByNavigation: User;
}
