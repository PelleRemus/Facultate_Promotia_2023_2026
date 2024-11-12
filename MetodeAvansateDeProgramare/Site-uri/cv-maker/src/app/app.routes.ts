import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { EditCvComponent } from './edit-cv/edit-cv.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { ProfilComponent } from './profil/profil.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomePageComponent },
    {
        path: 'profile',
        component: ProfilComponent,
        children: [
            { path: '', component: ProfilePageComponent, pathMatch: 'full' },
            { path: 'edit-cv', component: EditCvComponent },
        ],
    },
];
