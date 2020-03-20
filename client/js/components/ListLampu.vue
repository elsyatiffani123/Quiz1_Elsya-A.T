<template>
    <div>
        <div v-if="isAddLamp === false">
            <button class="btn btn-primary" type="button" @click="addNewLamp">Add New Lamp</button>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Nama</th>
                        <th>Stock</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(lampu,index) in lamps" :key="index">
                        <td>{{lampu.NamaLampu}}</td>
                        <td>{{lampu.StockLampu}}</td>
                        <td>
                            <a :href="'/lampu/updateLampu?IdLampu='+lampu.IdLampu" class="btn btn-warning">Edit</a>
                            <button class="btn btn-danger" @click="deleteLamp(lampu)">
                                <fa-icon icon="trash-alt"></fa-icon>
                                Delete
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div v-if="isAddLamp === true">
            <validation-observer ref="observer" v-slot="{validate,valid}">
                <form method="post" @submit.prevent="insertLamp">
                    <label class="col-form-label">Nama</label>
                    <validation-provider name="name" rules="required" v-slot="{errors}">
                        <input class="form-control" type="text" v-model="newLampu.NamaLampu" />
                        <span class="text-danger font-italic">{{errors[0]}}</span>
                    </validation-provider>
                    <br />

                    <label class="col-form-label">Stock</label>
                    <validation-provider name="stock" rules="required" v-slot="{errors}">
                        <input class="form-control" type="text" v-model="newLampu.StockLampu" />
                        <span class="text-danger font-italic">{{errors[0]}}</span>
                    </validation-provider>
                    <br />

                    
                    <button class="btn btn-primary" type="submit">
                        <fa-icon icon="check"></fa-icon>
                        Submit
                    </button>
                </form>
            </validation-observer>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component';
    import { LampuService, LampuModel, } from '../services/NSwagService';
    import { ValidationObserver } from 'vee-validate';
    import swal from 'sweetalert2';

    @Component({
        created: async function (this: ListLampu) {
            await this.getLamp();
        }
    })

    export default class ListLampu extends Vue {
        service: LampuService = new LampuService();

        employeeApps: LampuModel[] = [];

        isAddLamp = false;

        newLamp: LampuModel = {
            NamaLampu: '',
            StockLampu = 0
        }

        async getLamp(): Promise<void> {
            
            const urlParams = new URLSearchParams(window.location.search);
            const IdLampu = urlParams.get('IdLampu')?.valueOf();
            this.newLamp.idLampu = await this.service.getSpesificLamp(IdLampu);
            this.newLamp.idLampu?.value = IdLampu;

        }

        async insertLamp(): Promise<void> {
            const valid = await (this.$refs.observer as InstanceType<typeof ValidationObserver>).validate();

            if (valid == false) {
                return;
            }

            await this.service.insertLamp(this.newLampu);

            swal.fire({
                title: 'Yeayy!',
                icon: 'success',
                text: 'Success insert new data employee.'
            });

            await this.getLamp();
            this.isAddLamp = false;
        }

        addNewLamp(): void {
            this.isAddLamp = true;
            return;
        }

        async deleteLamp(lampu): Promise<void> {
            await this.service.deleteLamp(lampu);
            await this.getLamp();

            swal.fire({
                title: '~~yeayy~~',
                icon: 'success',
                text: 'Success delete employee ' + this.newLampu.idLampu
            })
        }
    }
 
</script>


