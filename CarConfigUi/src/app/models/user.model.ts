export interface User{
  id: number;
  login: string;
  username: string;
  //password: string;
  email: string;
  createdOn: number;
  token?: string;
}
