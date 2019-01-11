<?php
	 class C_tpu_device extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPU_DEVICE.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPU_DEVICE.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpu_deviceid' =>  $this->input->get_post('tpu_deviceid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thedevice' =>   $this->input->get_post('thedevice', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'templatename' =>   $this->input->get_post('templatename', TRUE)
                ,'sheetname' =>   $this->input->get_post('sheetname', TRUE)
            );
            $tpu_device = $this->m_tpu_device->setRow($data);
            print json_encode($tpu_device);
    }
    function newRow() {
            log_message('debug', 'TPU_DEVICE.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpu_deviceid' =>  $this->input->get_post('tpu_deviceid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thedevice' =>   $this->input->get_post('thedevice', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'templatename' =>   $this->input->get_post('templatename', TRUE)
                ,'sheetname' =>   $this->input->get_post('sheetname', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpu_device= $this->m_tpu_device->newRow($instanceid,$data);
            $return = $tpu_device;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPU_DEVICE.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpu_device = $this->m_tpu_device->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpu_device
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpu_device= $this->m_tpu_device->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpu_device= $this->m_tpu_device->getRows($sort);
                }
            }else{
              $tpu_device= $this->m_tpu_device->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_device
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPU_DEVICE.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpu_device= $this->m_tpu_device->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_device
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPU_DEVICE.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpu_device= $this->m_tpu_device->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpu_device
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPU_DEVICE.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpu_deviceid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpu_device->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpu_device', 'm_tpu_device');
    }
}
?>