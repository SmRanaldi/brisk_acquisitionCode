import pandas as pd
import numpy as np
import os
import sys

if(len(sys.argv)==2):
    if(os.path.isdir(sys.argv[1])):
        os.chdir(sys.argv[1])
        all_files = [x for x in os.listdir() if x.startswith('imus_') and x.endswith('.csv')]
        acquisitions = np.unique([x.split('_')[1] for x in all_files])

        headers = ['t','acc_x','acc_y','acc_z','gyr_x','gyr_y','gyr_z','mag_x','mag_y','mag_z','quat_1','quat_2','quat_3','quat_4']

        for acq in acquisitions:
            outFilename ='data_'+acq+'.csv'
            if(not os.path.isfile(outFilename)):
                data = {}
                files_acq = [x for x in all_files if acq in x]
                imus = [x.split('_')[2].split('.')[0] for x in files_acq]
                for imu in imus:
                    headers_imu = [imu+"_"+h for h in headers]
                    data[imu] = pd.read_csv('imus_'+acq+"_"+imu+".csv",header=None)
                    data[imu].columns = headers_imu
                first_t = np.max([val.iloc[0,0] for val in data.values()])
                for imu in imus:
                    data[imu] = data[imu][data[imu].iloc[:,0]>=first_t]
                lengths = np.min([val.shape[0] for val in data.values()])
                t = data[imus[0]].iloc[:lengths,0].copy(deep=True)
                t.reset_index(inplace=True,drop=True)
                for imu in imus:
                    data[imu] = data[imu].iloc[:lengths,1:]
                    data[imu].reset_index(inplace=True,drop=True)
                data_all = pd.concat([d for d in data.values()],axis=1)
                data_all['t'] = t
                data_all.to_csv(outFilename,index=None)