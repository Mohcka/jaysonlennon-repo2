import { UserAccountType } from 'src/enums/user-account-type';

export interface User {
  userId?: number;
  loginName: string;
  userAccountType: UserAccountType;
  firstName: string;
  lastName: string;
  apiKey?: string;
  password?: string;
}
