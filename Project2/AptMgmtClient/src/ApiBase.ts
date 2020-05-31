import { environment } from './environments/environment';

export class ApiBase {
    public static url(): string {
        if (process.env.NODE_ENV === 'development') {
            if (environment.memoryApi === true) {
                return 'api/';
            } else {
                return 'https://localhost:5001/api/v1/';
            }
        } else {
            return 'https://pipeline-app-jwl.azurewebsites.net/api/v1/';
        }
    }
}