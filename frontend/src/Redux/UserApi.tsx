import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";
import {IUser} from "../interface/IUser";

export const userAPI = createApi({
    reducerPath: 'userAPI',
    baseQuery: fetchBaseQuery({
        baseUrl: process.env.REACT_APP_USER_SERVICE_API_URL
    }),
    tagTypes: ['User'],
    endpoints: (builder) => ({
        getAllUsers: builder.query<IUser[], void>({
            query: () => `/`,
            providesTags: ['User']
        }),
        getUser: builder.query<IUser, number>({
            query: (id) => `/${id}`,
        }),
        register: builder.mutation<IUser, IUser>({
            query: (user) => ({
                url: '/register',
                method: 'POST',
                body: user
            }),
            invalidatesTags: ['User']
        }),
        updateUser: builder.mutation<IUser, IUser>({
            query: (user) => ({
                url: `//${user.id}`,
                method: 'PUT',
                body: user
            }),
            invalidatesTags: ['User']
        }),
        deleteUser: builder.mutation<IUser, IUser>({
            query: (user) => ({
                url: `/${user.id}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['User']
        }),
    })
})