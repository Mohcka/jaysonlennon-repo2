import { UserAccountType } from 'src/enums/user-account-type';

export interface User {
  id: number;
  loginName: string;
  /**
   * The user's specified role, can either be
   * tenant, manager or admin
   */
  userAccountType: UserAccountType;
  /**
   * Key used to authenticated user's request
   */
  apiKey?: string;
  /**
   * A user will only enter their password to authenticate,
   * never expect to receive the password from the server.
   */
  password?: string;
}
