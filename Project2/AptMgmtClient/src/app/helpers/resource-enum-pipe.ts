// https://dzone.com/articles/why-we-shound-not-use-function-inside-angular-temp
import { Pipe, PipeTransform } from '@angular/core';
import { Resource } from 'src/enums/Resource';

@Pipe({
  name: 'resourceAsString',
  pure: true
})

export class ResourceEnumPipe implements PipeTransform {

  transform(value: Resource, args?: any): String {
    return this.resourceAsString(value);
  }

  resourceAsString(value: Resource): String {
      switch (value) {
          case Resource.Internet: return Resource[Resource.Internet];
          case Resource.Power: return Resource[Resource.Power];
          case Resource.Rent: return Resource[Resource.Rent];
          case Resource.Trash: return Resource[Resource.Trash];
          case Resource.Water: return Resource[Resource.Water];
      }
  }
}