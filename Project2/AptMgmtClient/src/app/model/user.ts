export interface User {
  id: number;
  loginName: string;
  password: string;
  userAccountType: string;
  apiKey?: string;
}
