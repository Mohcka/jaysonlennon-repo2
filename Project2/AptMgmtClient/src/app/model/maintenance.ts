/**
 * A standard maintance request issued by a tenant
 */
export interface Maintenance {
  /**
   * Unique id
   */
  id: number;
  /**
   * The maintenance request's current completion status
   */
  status: string;
  /**
   * Reason why request was made. Marked `"Complete"` when request is closed.
   */
  reason: string;
  /**
   * The data the request was made
   */
  date: string;
  /**
   * The catagory specifying the type of maintenance request that was issued.
   */
  category: string;
}
