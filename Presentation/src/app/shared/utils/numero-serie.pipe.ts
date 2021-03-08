import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numeroSerie'
})
export class NumeroSeriePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    return `${value.substring(0, 5)}-${value.substring(5, 8)}-${value[8]}-${value.substring(9, 13)}/${value.substring(13, 17)}`;
  }
}
