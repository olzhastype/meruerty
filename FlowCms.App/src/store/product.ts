import { defineStore } from 'pinia';

export const useProductStore = defineStore('product', {
    state: () => ({
        items: []
    }),
    getters: {},
    actions: {
        async initFetch() {
            fetch('https://dummyjson.com/products')
                .then((res) => res.json())
                .then((json) => (this.items = json.products));
        }
    }
});
