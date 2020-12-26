using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.15  �豸�����㷨�飨DV��DEVICE ��51497
    /// </summary>
    public class PIDDv : PIDBindAlgorithm
    {

        ///<summary>
        /// ����ź�ģʽ���ò������������Out1��Out2�źŵ���ʽ��
        ///0�����ָ��Ϊ���������塣����Ӧ����Ϊ��ʱ��STOP�ź���Чʱ���ź�Reset
        ///1�����ָ��Ϊ�����С�����Ӧ����Ϊ��ʱ��STOP�ź���Чʱ���ź�Reset
        ///2�����ָ��Ϊ���źţ�����Ӧ����Ϊ��ʱ��STOP�ź���Чʱ���ź�Reset
        ///3�����ָ��Ϊ���źš���������ָ����Чʱ���ź�Reset���˷�ʽ�޲���ʧ��
        ///4�����ָ��ͬ0������Ϊ��ʱ���źŲ�Reset
        ///5�����ָ��ͬ1������Ϊ��ʱ���źŲ�Reset
        ///6�����ָ��ͬ2������Ϊ��ʱ���źŲ�Reset
        ///7�����ָ��ͬ3������Ϊ��ʱ���źŲ�Reset
        ///8�����ָ��ͬ0������Ϊ��ʱ��Ҳ�ܷ����ź�
        ///9�����ָ��ͬ1������Ϊ��ʱ��Ҳ�ܷ����ź�
        ///10�����ָ��ͬ2������Ϊ��ʱ��Ҳ�ܷ����ź�
        ///11�����ָ��ͬ 3������Ϊ��ʱ��Ҳ�ܷ����ź�
        /// </summary>
        public const string ParamOutM = PIDAlgorithmToken.prefixParam + "OutM";

        ///<summary>
        /// ����źŶ�ʱ���ò������������ Out1��Out2 �źŵ���Ч����(��λΪ��)������
        ///���ָ��Ϊ�����������������ʱ��Ч��
        /// </summary>
        public const string ParamSetT = PIDAlgorithmToken.prefixParam + "SetT";

        ///<summary>
        /// ����źŶ�ʱ���ò������������ Out1��Out2 �źŵ�ռ�ձ�(��λΪ��)��������
        ///��ָ��Ϊ������ʱ��Ч��ÿ�����峤��Ϊ SetT������ ResT ʱ����Ϊ 0���� ResT/Ϊ 0 ʱ��ResT=SetT/2
        /// </summary>
        public const string ParamRseT = PIDAlgorithmToken.prefixParam + "RseT";

        ///<summary>
        /// �豸ȱʡģʽ���ò����������豸���ϵ硢�͵ء����ϻ򱣻��������ȷ�ʽ�ظ���
        ///��ȱʡģʽ��0���豸ȱʡģʽΪ�ֶ�ģʽ��1���豸ȱʡģʽΪ�Զ�ģʽ
        /// </summary>
        public const string ParamMod0 = PIDAlgorithmToken.prefixParam + "Mod0";

        ///<summary>
        /// STOPָ����������ָ���Ƿ���Stop״̬ʱ��Ч��
        ///0 �� ��ִ��STOPָ��  1 �� ִ��STOPָ��
        ///2 �� ��ִ��STOPָ��ҵ��豸����ֹͣ״̬ʱ�����ܷ�����ָ��
        ///3 �� ִ��STOPָ��ҵ��豸����ֹͣ״̬ʱ�����ܷ�����ָ��
        ///4 �C  ��ִ��STOPָ����з�����ָ��ʱ������STOPָ�
        ///5 - ִ�� STOP ָ����з�����ָ��ʱ������ STOP ָ�
        /// </summary>
        public const string ParamSTP = PIDAlgorithmToken.prefixParam + "STP";

        ///<summary>
        /// �ֶ����ȼ����ò���������CRT/���̵��ֶ�ָ���Ƿ���ֱ�ӽ��豸�л����ֶ�ģʽ��
        ///0 �� �ֶ�OPEN/CLOSE/STOPָ��ܽ��豸�л����ֶ�ģʽ�������ָ����Ч��
        ///1  �� �ֶ�OPEN/CLOSE/STOPָ����ܽ��豸�л����ֶ�ģʽ�������ָ���� Ч��
        ///���� �� �ֶ� OPEN/CLOSE/STOP ָ��ܽ��豸�л����ֶ�ģʽ�������ָ�� ��Ч��
        /// </summary>
        public const string ParamMP = PIDAlgorithmToken.prefixParam + "MP";

        ///<summary>
        /// ���ϱ�������������������豸�����źš���բ������ʧ���Ƿ�������ָ��
        /// 0  �� ��һ�źŽ��������ָ�
        /// 1  �� ��һ�źŽ����������ָ�
        /// </summary>
        public const string ParamFLB = PIDAlgorithmToken.prefixParam + "FLB";

        ///<summary>
        /// ��բ��λ�����������������բ(����)�����ź�ToTP�����������ָ���ָ����բ�жϵķ����źţ�
        ///0  �� ��բ�źŶ�Ӧ�����ΪOut2������ָ�������FB2�仯ʱΪ��բ(Trip���)
        ///1  �� ��բ�źŶ�Ӧ�����ΪOut1������ָ�������FB1�仯ʱΪ��բ(Trip���)
        ///2 �� ����ָ�������FB1��FB2�仯ʱΪ��բ(Trip���)
        /// </summary>
        public const string ParamTout = PIDAlgorithmToken.prefixParam + "Tout";

        ///<summary>
        /// �豸�г�ʱ�䡣��ָ����󣬾�Toverʱ�����Ӧ������Ϊ1ʱ������ʧ�ܡ�Tover>=SetT.��
        /// </summary>
        public const string ParamTover = PIDAlgorithmToken.prefixParam + "Tover";

        //--------------------------------------------------1


        ///<summary>
        /// ����(����)��ָ�ֻҪ�ó���ָ��Ϊ 1 ʱ�������豸�����ֶ����Զ�ģʽ����
        ///�������Ƿ����㣬�������ָ�� Out1�����������෴������ָ������豸�е� ȱʡģʽ��
        ///����ָ���Ϊ 1 ʱ��˳�ؼ��ֶ��ķ�����ָ����Ч�����ǿ��Խ����� �Զ�ģʽ�л���
        /// </summary>
        public const string InputOvr1 = PIDAlgorithmToken.prefixInput + "Ovr1";

        ///<summary>
        /// ע��Ovr1,Ovr2 ָ������ʧ���ź� OPFL ����֮��ֻ��һ��ȱʡ��ʽ�����Ǳ���Ϊȱʡ��ʽ��
        /// </summary>
        public const string InputOvr2 = PIDAlgorithmToken.prefixInput + "Ovr2";

        ///<summary>
        /// �������ź�Ϊ 1 ʱ��˳�ؼ��ֶ��Ŀ�ָ�� Out1 ����Ч
        /// </summary>
        public const string InputS1p = PIDAlgorithmToken.prefixInput + "S1p";

        ///<summary>
        /// �������ź�Ϊ 1 ʱ��˳�ؼ��ֶ��Ĺ�ָ�� Out2 ����Ч
        /// </summary>
        public const string InputS2p = PIDAlgorithmToken.prefixInput + "S2p";

        ///<summary>
        /// ǿ���ֶ��������ź���Ϊ 1 ʱ�����޾͵ء���������������ʱ���㷨Ϊǿ���ֶ���ʽ
        /// </summary>
        public const string InputToM = PIDAlgorithmToken.prefixParam + "ToM";

        ///<summary>
        /// �Զ����󣬵��Զ������� 0 ��Ϊ 1 ����ǿ���ֶ���Ϊ 1 ʱ���㷨��Ϊ�Զ���ʽ
        /// </summary>
        public const string InputReqA = PIDAlgorithmToken.prefixInput + "ReqA";

        ///<summary>
        /// ���豸�����Զ�(˳��)״̬���������Ӧ����������ʱ�����źŽ����������Ӧ
        ///�����Out1,Out2,��Out3��(��ƽ�����ڲ�����) ע���ڹ��� ACK ���紦���Զ�״̬���������Զ������
        /// </summary>
        public const string InputDmd1 = PIDAlgorithmToken.prefixInput + "Dmd1";
        public const string InputDmd2 = PIDAlgorithmToken.prefixInput + "Dmd2";
        public const string InputDmd3 = PIDAlgorithmToken.prefixInput + "Dmd3";

        ///<summary>
        /// ����� Out1��Out2 ���Ӧ���豸����״̬�����ź�
        /// </summary>
        public const string InputFB1 = PIDAlgorithmToken.prefixInput + "FB1";

        public const string InputFB2 = PIDAlgorithmToken.prefixInput + "FB2";
        ///<summary>
        /// �豸���ھ͵�״̬�����ȼ���ߣ��豸���������ֹ�����е�ȱʡģʽ���κ��������Ч��
        /// </summary>
        public const string InputFB3 = PIDAlgorithmToken.prefixInput + "FB3";

        ///<summary>
        /// ��բ(����)�����źš������ź�Ϊ1ʱ���ɲ���Toutָ�������ֵ���κη����� ���������ֹ�������豸�е�ȱʡģʽ�����ȼ������ھ͵ء�
        /// </summary>
        public const string InputToTP = PIDAlgorithmToken.prefixInput + "ToTP";

        //--------------------------------------------------1
        ///<summary>
        /// ��ָ�����
        /// </summary>
        public const string ResultOut1 = PIDAlgorithmToken.prefixResult + "Out1";

        ///<summary>
        /// ��ָ�����
        /// </summary>
        public const string ResultOut2 = PIDAlgorithmToken.prefixResult + "Out2";

        ///<summary>
        /// ָͣ�����
        /// </summary>
        public const string ResultOut3 = PIDAlgorithmToken.prefixResult + "Out3";

        ///<summary>
        /// �ֶ�ָʾ�����㷨Ϊ�ֶ���ʽʱ���Ϊ 1����ʱ������͵ػ��߳����⣬�� ToOpen��ToClose��ToStop ������
        /// </summary>
        public const string ResultM = PIDAlgorithmToken.prefixResult + "M";

        ///<summary>
        /// �Զ�ָʾ�����㷨Ϊ�Զ���ʽʱ���Ϊ 1����ʱ���͵ػ򳬳��⣬�� Dmd1��Dmd2��Dmd3 ������
        /// </summary>
        public const string ResultA = PIDAlgorithmToken.prefixResult + "A";

        ///<summary>
        /// �豸״̬���� FB1 Ϊ 1 ʱ�� 1���� FB2 Ϊ 1 ʱ�� 0��
        /// </summary>
        public const string ResultStat = PIDAlgorithmToken.prefixResult + "Stat";

        ///<summary>
        /// �豸���ϣ��� FB1��FB2 ͬΪ 1 ʱ�� 1������Ϊ 0��
        /// </summary>
        public const string ResultFL = PIDAlgorithmToken.prefixResult + "FL";

        ///<summary>
        /// ��բ��ʾ�������κ�ָ������豸�������ھ͵أ���ָ�����豸����״̬�����ź�
        ///(ͨ��Ϊ FB2)ȴ�����仯ʱ�����ź��� 1����ʱ˳�ؼ��ֶ�����������ֹ������ CRT/ ���̵�ȷ�ϼ�����λΪ 0��
        /// </summary>
        public const string ResultTrip = PIDAlgorithmToken.prefixResult + "Trip";

        ///<summary>
        /// ����ʧ�ܣ������ָ��(�����ɲ��� SetT ����)��������ʱһ��ʱ��(�豸�г�ʱ�䣬
        ///�ɲ��� Tover ���壬Tover>=SetT���� ToverС��SetT���� Tover=SetT;��Ϊ�����������
        ///�� Tover=0 ʱ��Tover=5)��δ�յ���Ӧ�ķ����źţ�����Ϊ����ʧ�ܡ����ź��� 1�� ��ʱ˳�ؼ��ֶ�����������ֹ������ CRT/���̵�ȷ�ϼ�����λΪ 0��
        /// </summary>
        public const string ResultOpFL = PIDAlgorithmToken.prefixResult + "OpFL";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamOutM] = new PIDAlgorithmVar(ParamOutM, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetT] = new PIDAlgorithmVar(ParamSetT, false, PIDVarDataType.Unknown);
            this.calcParams[ParamRseT] = new PIDAlgorithmVar(ParamRseT, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMod0] = new PIDAlgorithmVar(ParamMod0, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSTP] = new PIDAlgorithmVar(ParamSTP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMP] = new PIDAlgorithmVar(ParamMP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamFLB] = new PIDAlgorithmVar(ParamFLB, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTout] = new PIDAlgorithmVar(ParamTout, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTover] = new PIDAlgorithmVar(ParamTover, false, PIDVarDataType.Unknown);
            this.calcParams[InputOvr1] = new PIDAlgorithmVar(InputOvr1, true, PIDVarDataType.DM);
            this.calcParams[InputOvr2] = new PIDAlgorithmVar(InputOvr2, true, PIDVarDataType.DM);
            this.calcParams[InputS1p] = new PIDAlgorithmVar(InputS1p, true, PIDVarDataType.DM);
            this.calcParams[InputS2p] = new PIDAlgorithmVar(InputS2p, true, PIDVarDataType.DM);
            this.calcParams[InputToM] = new PIDAlgorithmVar(InputToM, false, PIDVarDataType.Unknown);
            this.calcParams[InputReqA] = new PIDAlgorithmVar(InputReqA, true, PIDVarDataType.DM);
            this.calcParams[InputDmd1] = new PIDAlgorithmVar(InputDmd1, true, PIDVarDataType.DM);
            this.calcParams[InputDmd2] = new PIDAlgorithmVar(InputDmd2, true, PIDVarDataType.DM);
            this.calcParams[InputDmd3] = new PIDAlgorithmVar(InputDmd3, true, PIDVarDataType.DM);
            this.calcParams[InputFB1] = new PIDAlgorithmVar(InputFB1, true, PIDVarDataType.DM);
            this.calcParams[InputFB2] = new PIDAlgorithmVar(InputFB2, true, PIDVarDataType.DM);
            this.calcParams[InputFB3] = new PIDAlgorithmVar(InputFB3, true, PIDVarDataType.DM);
            this.calcParams[InputToTP] = new PIDAlgorithmVar(InputToTP, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultOut1] = new PIDAlgorithmVar(ResultOut1, false, PIDVarDataType.DM);
            this.calcResults[ResultOut2] = new PIDAlgorithmVar(ResultOut2, false, PIDVarDataType.DM);
            this.calcResults[ResultOut3] = new PIDAlgorithmVar(ResultOut3, false, PIDVarDataType.DM);
            this.calcResults[ResultM] = new PIDAlgorithmVar(ResultM, false, PIDVarDataType.DM);
            this.calcResults[ResultA] = new PIDAlgorithmVar(ResultA, false, PIDVarDataType.DM);
            this.calcResults[ResultStat] = new PIDAlgorithmVar(ResultStat, false, PIDVarDataType.DM);
            this.calcResults[ResultFL] = new PIDAlgorithmVar(ResultFL, false, PIDVarDataType.DM);
            this.calcResults[ResultTrip] = new PIDAlgorithmVar(ResultTrip, false, PIDVarDataType.DM);
            this.calcResults[ResultOpFL] = new PIDAlgorithmVar(ResultOpFL, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4������˵��
        ///������ʽ�����֣�0���Զ���1��PV1��2��PV2��3��PV3�� �Զ�ʱ�����ʽ�����֣�0��ƽ��ֵ��1�����ֵ��2����Сֵ��3���м�ֵ��4��PV1��5
        ///��PV2��6��PV3��
        ///?	��������ʽ���Զ�ʱ��
        ///1)   �����������㶼�ǻ��㣬�����Ϊ���㣬������ֲ��䡣�����������ź� ALM
        ///Ϊ�棬���������ֶ��ź� MRE Ϊ�档
        ///2)   ��������������������ǻ��㣬�����������һ���õ��ֵ�������������ź� ALM
        ///Ϊ�档
        ///3)   ���������������һ���ǻ��㣬�򰴶������������㷨���ԭ������
        ///4)   ����������붼�Ǻõ㣬���Ҵ����Զ�����״̬��
        ///a. �������ƫ��������Խ�ޣ��������� Range�������Ϊ��ȫֵ SaftV������������ �ź� ALM Ϊ�棬���������ֶ��ź� MRE Ϊ�档
        ///b. �������ƫ����ĳ������(����Ϊ A ·)������·֮��(����Ϊ B ·�� C ·)ƫ �Խ��(���� Range)��������·֮��ƫ�Խ�ޣ������ȡ����·(��ǰ��� ��� B ·�� C ·)��ƽ��ֵ��
        ///c. �������֮���ƫ�û�г��� Range����ô����ָ���ķ�ʽ�����
        ///?	���ڹ�����ʽ��ָ���� PV1 ���� PV2 ���� PV3 Ϊ���ʱ�� ֻ�е�ָ��������Ϊ�õ�ʱ�����㷨��Żᰴ���û���ָ������������Զ��л����Զ�
        ///����״̬�� 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double outm =  this.calcParams[ParamOutM].Value;
            double sett =  this.calcParams[ParamSetT].Value;
            double rset =  this.calcParams[ParamRseT].Value;
            double mod0 =  this.calcParams[ParamMod0].Value;
            double stp =  this.calcParams[ParamSTP].Value;
            double mp =  this.calcParams[ParamMP].Value;
            double flb =  this.calcParams[ParamFLB].Value;
            double tout =  this.calcParams[ParamTout].Value;
            double tover =  this.calcParams[ParamTover].Value;
            double ovr1 =  this.calcParams[InputOvr1].Value;
            double ovr2 =  this.calcParams[InputOvr2].Value;
            double s1p =  this.calcParams[InputS1p].Value;
            double s2p =  this.calcParams[InputS2p].Value;
            double tom =  this.calcParams[InputToM].Value;
            double reqa =  this.calcParams[InputReqA].Value;
            double dmd1 =  this.calcParams[InputDmd1].Value;
            double fb1 =  this.calcParams[InputFB1].Value;
            double fb3 =  this.calcParams[InputFB3].Value;
            double totp =  this.calcParams[InputToTP].Value;
            //double out1 =  this.calcResults[ResultOut1].Value;
            //double out2 =  this.calcResults[ResultOut2].Value;
            //double out3 =  this.calcResults[ResultOut3].Value;
            //double m =  this.calcResults[ResultM].Value;
            //double a =  this.calcResults[ResultA].Value;
            //double stat =  this.calcResults[ResultStat].Value;
            //double fl =  this.calcResults[ResultFL].Value;
            //double trip =  this.calcResults[ResultTrip].Value;
            //double opfl =  this.calcResults[ResultOpFL].Value;

        }
        
    }
}