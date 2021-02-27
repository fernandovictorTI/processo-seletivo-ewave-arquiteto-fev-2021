import { NgModule } from '@angular/core';
import { cozinhasRoutedComponents, CozinhaRoutingModule } from './cozinha-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    CozinhaRoutingModule
  ],
  declarations: [cozinhasRoutedComponents],
  providers: []
})
export class CozinhaModule {
}