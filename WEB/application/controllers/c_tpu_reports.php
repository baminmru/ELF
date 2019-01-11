<?php
	 class C_tpu_reports extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPU_REPORTS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPU_REPORTS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpu_reportsid' =>  $this->input->get_post('tpu_reportsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'reporttype' =>   $this->input->get_post('reporttype', TRUE)
                ,'thefile' =>   $this->input->get_post('thefile', TRUE)
                ,'thefile_ext' =>   $this->input->get_post('thefile_ext', TRUE)
            );
            $tpu_reports = $this->m_tpu_reports->setRow($data);
            print json_encode($tpu_reports);
    }
    function newRow() {
            log_message('debug', 'TPU_REPORTS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpu_reportsid' =>  $this->input->get_post('tpu_reportsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'reporttype' =>   $this->input->get_post('reporttype', TRUE)
                ,'thefile' =>   $this->input->get_post('thefile', TRUE)
                ,'thefile_ext' =>   $this->input->get_post('thefile_ext', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpu_reports= $this->m_tpu_reports->newRow($instanceid,$data);
            $return = $tpu_reports;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPU_REPORTS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpu_reports = $this->m_tpu_reports->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpu_reports
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
            	$sort[] = array('property'=>'reporttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpu_reports= $this->m_tpu_reports->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpu_reports= $this->m_tpu_reports->getRows($sort);
                }
            }else{
              $tpu_reports= $this->m_tpu_reports->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_reports
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPU_REPORTS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'reporttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpu_reports= $this->m_tpu_reports->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_reports
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
        log_message('debug', 'TPU_REPORTS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'reporttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpu_reports= $this->m_tpu_reports->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpu_reports
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
        log_message('debug', 'TPU_REPORTS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpu_reportsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpu_reports->deleteRow($tempId);
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
        $this->load->model('M_tpu_reports', 'm_tpu_reports');
    }
}
?>