import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class SettingsService {
    GetSettings(): Observable<ChromambooSettings> {
        throw new Error('Method not implemented.');
    }

    constructor(private httpClient: HttpClient) { }
}

