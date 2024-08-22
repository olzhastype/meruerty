<script setup lang="ts">
import { useProductStore } from '@/store/product';
import { onMounted } from 'vue'

const store = useProductStore();


onMounted(() => {
    store.initFetch()

})
</script>
<template>
    <div class="card">
        <h1>Косметика</h1>
    </div>
    <div class="card" v-for="el in store.items">
        <p> {{ el.title }}</p>
        <img :src="el.thumbnail" alt="">

        <p>Бренд: {{ el.brand }}</p>
        <p>Цена: {{ el.price }}</p>
        <p>Категория: {{ el.category }}</p>
    </div>
</template>
