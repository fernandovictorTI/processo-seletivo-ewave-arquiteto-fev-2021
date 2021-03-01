import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Store } from '@ngrx/store';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { GarcomListComponent } from './garcom-list.component';
import * as garconsActions from '../store/garcons.actions';
import { GarcomState } from '../store/garcons.reducers';

const initialState = {
    loaded: false,
    error: null,
    isCreated: false,
    entities: {
        '1': {
            id: '1',
            nome: 'Fernando',
            telefone: '65 98484484'
        },
        '2': {
            id: '2',
            nome: 'Joao de Deus',
            telefone: '65 98484484'
        }
    },
    ids: ['1', '2']
};


describe('GarcomListComponent', () => {
    let component: GarcomListComponent;
    let fixture: ComponentFixture<GarcomListComponent>;
    let store: MockStore<GarcomState>;
    let dispatchSpy;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [GarcomListComponent],
            providers: [
                provideMockStore({ initialState })
            ]
        })
            .compileComponents();

        store = TestBed.inject(MockStore);
        dispatchSpy = spyOn(store, 'dispatch');
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(GarcomListComponent);
        component = fixture.componentInstance;
        store.setState(initialState);
        fixture.detectChanges();
    });

    // it('should create', () => {
    //     expect(component).toBeTruthy();
    // });

    // it('action fetch garcons should have been called', (done => {
    //     expect(dispatchSpy).toHaveBeenCalled();
    //     expect(dispatchSpy).toHaveBeenCalledWith(garconsActions.ObterGarcons({ quantidade: 10 }));

    //     component.garcons.subscribe((data) => {
    //         expect(data.length).toEqual(2);
    //         done();
    //     });
    // }));
});